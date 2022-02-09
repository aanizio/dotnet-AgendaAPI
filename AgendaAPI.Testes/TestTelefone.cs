using Xunit;
using AgendaAPI.Models;

namespace AgendaAPI.Testes;

public class TestTelefone
{
    [Fact]
    public void Vazio_DeveRetornarInvalido()
    {
        var telefone = new Telefone("");
        var actual = telefone.Valido();
        Assert.False(actual);
    }

    [Fact]
    public void NoveDigitosEComHifen_DeveRetornarValido()
    {
        var telefone = new Telefone("99999-9999");
        var actual = telefone.Valido();
        Assert.True(actual);
    }

    [Fact]
    public void OitoDigitosEComHifen_DeveRetornarValido()
    {
        var telefone = new Telefone("9999-9999");
        var actual = telefone.Valido();
        Assert.True(actual);
    }

    [Fact]
    public void CastParaString()
    {
        const string CONTEUDO = "99999-9999";
        var telefone = new Telefone(CONTEUDO);
        string telefoneString = telefone;
        Assert.Equal(CONTEUDO, telefoneString);
    }

    [Fact]
    public void CastDeString()
    {
        const string CONTEUDO = "99999-9999";
        Telefone telefone = CONTEUDO;
        Assert.Equal(telefone.Valor, CONTEUDO);
    }
}