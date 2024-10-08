namespace GutCheck.Web.Models
{
    public static class ViewModelFactory
    {
        public static WeightViewModel CreateWeightViewModel(IEnumerable<ServerMessage>? messages = null)
        {
            var model =  new WeightViewModel
            {
                Subtitle = "Weight",
                Data = new Data.WeightRecordData
                {
                    Date = DateTime.Now,
                    Weight = 0
                },
                Messages = new ServerMessageCollection()
            };

            if (messages != null)
            {
                foreach (var message in messages)
                {
                    model.Messages.AddMessage(message);
                }
            }

             return model;
        }
    }
}
