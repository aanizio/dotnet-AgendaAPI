using System;
using System.Text.RegularExpressions;

namespace AgendaAPI.Models;

public class Telefone
{
    private const string REGEX_PATTERN = @"\d{4,5}-\d{4}";

    public Telefone(string valor)
    {
        Valor = valor;
    }

    public string Valor { get; }

    public bool Valido()
    {
        return Regex.IsMatch(Valor, REGEX_PATTERN);
    }

    public static implicit operator string(Telefone tel) => tel.Valor;
    public static implicit operator Telefone(string valor) => new Telefone(valor);
}