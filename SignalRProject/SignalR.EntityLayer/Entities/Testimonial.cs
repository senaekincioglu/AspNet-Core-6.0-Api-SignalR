namespace SignalR.EntityLayer.Entities
{
    public class Testimonial //Referanslar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; } //yorum
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
