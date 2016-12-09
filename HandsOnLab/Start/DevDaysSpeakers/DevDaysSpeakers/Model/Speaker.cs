namespace DevDaysSpeakers.Model
{
	public class Speaker : AppServiceHelpers.Models.EntityData
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public string Website { get; set; }
		public string Title { get; set; }
		public string Avatar { get; set; }
    }
}
