namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public class BookForUpdateDto : BookForManipulationDto
    {
        public override string Description
        {
            get
            {
                return base.Description;
            }
            set
            {
                base.Description = value;
            }
        }
    }
}
