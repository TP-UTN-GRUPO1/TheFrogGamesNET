﻿using System.ComponentModel.DataAnnotations;

namespace Contract.User.Request;
public class CreateUserRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es requerido")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "El email es requerido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Contraseña requerida")]
    public string Password { get; set; } = string.Empty;

}
