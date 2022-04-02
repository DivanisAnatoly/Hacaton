using NuretaNeko.Domain.Entities.Enums;

namespace NuretaNeko.API.Requests.Skill
{
    public record AddSkillOptionRequest
    {
        public string OptionKey { get; set; }
        public string Value { get; set; }
        public int Score { get; set; }
        public Guid SkillId { get; set; }
    }
}
