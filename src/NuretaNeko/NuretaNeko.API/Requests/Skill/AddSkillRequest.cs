using NuretaNeko.Domain.Entities.Enums;

namespace NuretaNeko.API.Requests.Skill
{
    public record AddSkillRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public SkillPriority Priority { get; set; }
    }
}
