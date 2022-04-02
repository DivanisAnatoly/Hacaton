using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuretaNeko.AppModel.Repositories;
using NuretaNeko.AppModel.Services;
using NuretaNeko.AppModel.Services.Contracts;
using NuretaNeko.AppModel.Services.Storage;
using NuretaNeko.Domain.Entities;
using NuretaNeko.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.Services.Services
{
    public class AppService : IAppService
    {
        private readonly IStorageService _storageService;
        private readonly ISkillRepository _skillRepository;
        private readonly ISkillOptionRepository _skillOptionRepository;
        private readonly IResumeRepository _resumeRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public AppService(ISkillRepository skillRepository, IMapper mapper, IStorageService storageService,
            ISkillOptionRepository skillOptionRepository, IResumeRepository resumeRepository,
            ICandidateRepository candidateRepository)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
            _storageService = storageService;
            _skillOptionRepository = skillOptionRepository;
            _resumeRepository = resumeRepository;
            _candidateRepository = candidateRepository;
        }

        public async Task<AddResumeDTO.Response> AddResume(AddResumeDTO.Request request, CancellationToken cancellationToken)
        {
            var candidate = _mapper.Map<Candidate>(request.Candidate);
            var resume = request.Resume;

            if (resume == null)
            {
                return new AddResumeDTO.Response
                {
                    IsSuccess = false,
                    ErrorMsg = "Empty resume"
                };
            }

            //string fileName = await _storageService.SaveCandidatePhoto(request.Candidate.Photo, cancellationToken);

            //if (fileName == null)
            //{
            //    return new AddResumeDTO.Response
            //    {
            //        IsSuccess = false,
            //        ErrorMsg = "Storage error"
            //    };
            //}

            candidate.Photo = "photo";


            int score = 0;
            int maxScore = 0;
            var skillsInfo = resume.SkillsInfo;

            var reviewedSkills = await _skillRepository.FindAll()
                .Where(x => skillsInfo.Keys.Contains(x.Code))
                .ToListAsync(cancellationToken);


            foreach (var skill in reviewedSkills)
            {
                int maxSkillValue = await _skillOptionRepository.FindAll()
                    .Where(so => so.SkillId == skill.Guid).Select(so => so.Score).MaxAsync();
                maxScore += maxSkillValue;
            }

            foreach (var skill in skillsInfo)
            {
                int skillValue = await _skillOptionRepository.FindAll()
                    .Where(so => so.OptionKey == skill.Value).Select(so => so.Score).SumAsync();
                score += skillValue;
            }

            double finalScore = Math.Round((score / (double)maxScore)*100,2);

            var formData = JsonConvert.SerializeObject(skillsInfo);

            Resume resumeObj = new()
            {
                Position = resume.Position,
                Score = finalScore,
                FormData = formData
            };

            await _resumeRepository.Add(resumeObj, cancellationToken);

            candidate.ResumeId = resumeObj.Guid;

            await _candidateRepository.Add(candidate, cancellationToken);

            return new AddResumeDTO.Response
            {
                Guid = resumeObj.Guid,
                IsSuccess = true,
            };
        }

        public async Task<AddSkillDTO.Response> AddSkill(AddSkillDTO.Request request, CancellationToken cancellationToken)
        {
            var skill = _mapper.Map<Skill>(request);
            await _skillRepository.Add(skill, cancellationToken);
            return new AddSkillDTO.Response
            {
                Guid = skill.Guid,
                IsSuccess = true
            };
        }

        public async Task<AddSkillOptionDTO.Response> AddSkillOption(AddSkillOptionDTO.Request request, CancellationToken cancellationToken)
        {
            var option = _mapper.Map<SkillOption>(request);
            //dish.Photo = fileName;
            //dish.DishStatus = DishStatus.Active;
            await _skillOptionRepository.Add(option, cancellationToken);
            return new AddSkillOptionDTO.Response
            {
                Guid = option.Guid,
                IsSuccess = true
            };
        }

        public async Task<GetResumesDTO.Response> GetResumes(CancellationToken cancellationToken)
        {
            List<ShortCandidateCardDTO> cardDTOs = new();
            var candidates = await _candidateRepository.FindAll().Include(c => c.Resume).ToListAsync();

            foreach (var candidate in candidates)
            {
                var card = new ShortCandidateCardDTO()
                {
                    Name = candidate.Name,
                    Photo = candidate.Photo,
                    Position = ((Position)candidate.Resume.Position).EnumToString(),
                    Score = candidate.Resume.Score
                };
                cardDTOs.Add(card);
            }

            return new GetResumesDTO.Response
            {
                Cards = cardDTOs,
                IsSuccess = true
            };
        }
    }
}
