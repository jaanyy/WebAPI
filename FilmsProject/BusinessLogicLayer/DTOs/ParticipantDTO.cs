using System;

namespace FilmsProject.BusinessLogicLayer.DTOs
{
    public class ParticipantDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
        public bool IsActor { get; set; }
        public bool IsProducer { get; set; }
    }
}
