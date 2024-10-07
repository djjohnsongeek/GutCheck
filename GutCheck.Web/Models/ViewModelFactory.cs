namespace GutCheck.Web.Models
{
    public static class ViewModelFactory
    {
        public static WeightViewModel CreateWeightViewModel()
        {
            return new WeightViewModel
            {
                Subtitle = "Weight",
                Data = new Data.WeightRecordData
                {
                    Date = DateTime.Now,
                    Weight = 0
                }
            };
        }
    }
}
