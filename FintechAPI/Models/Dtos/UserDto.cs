namespace FintechApi.Models.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }
    


    }

    public class CreateUserDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }


    }

    public class UpdateUserDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }      


    }

    public class UpdatePasswordUserDto
    {
        public string Password { get; set; }


    }


}
