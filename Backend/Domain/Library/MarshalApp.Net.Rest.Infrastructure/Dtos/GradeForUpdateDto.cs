namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public class GradeForUpdateDto : GradeForManipulationDto
    {
        public override string Subject
        {
            get
            {
                return base.Subject;
            }

            set
            {
                base.Subject = value;
            }
        }


        public override decimal Qualification
        {
            get
            {
                return base.Qualification;
            }

            set
            {
                base.Qualification = value;
            }
        }

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


        public override string Status
        {
            get
            {
                return base.Status;
            }

            set
            {
                base.Status = value;
            }
        }



    }
}
