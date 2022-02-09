using System;
using System.Text.RegularExpressions;

namespace AgendaAPI.Models;

public class Telefone
{
    const string REGEX_PATTERN = @"\d{4,5}-\d{4}";

    private string _valor;

    public Telefone(string valor)
    {
        _valor = valor;
    }

    public bool Valido()
    {
        return Regex.IsMatch(_valor, REGEX_PATTERN);
    }

    public static implicit operator string(Telefone tel) => tel._valor;
}