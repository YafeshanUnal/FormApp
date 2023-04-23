using Core.Domain.Entities;

namespace Core.Application.Wrappers.Requests.Form
{
    public class CreateFormRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public string Fields { get; set; }
    }
}
