using System;
using System.ComponentModel;
using System.Reflection;

namespace SGCOM.Utilities
{
    public class Enums
    {
       public enum eStatus
        {
            [Description("Inativo")]
            Inativo = 0,
            [Description("Ativo")]
            Ativo = 1,
        }

        public enum eTipoPessoa
        {
            [Description("Fisica")]
            Fisica = 0,
            [Description("Jurídica")]
            Juridica = 1
        }

        public enum eSexo
        {
            [Description("Feminino")]
            Feminino = 0,
            [Description("Masculino")]
            Masculino = 1
        }

        public enum eDiasDaSemana
        {
            /// <summary> Domingo: por fundamentação bíblica e etimológica, é considerado o primeiro dia da semana </summary>
            [Description("Domingo")]
            Domingo = 0,

            /// <summary> Segunda-Feira: segundo dia da semana </summary>
            [Description("Segunda-Feira")]
            Segunda = 1,

            /// <summary> Terça-Feira: terceiro dia da semana </summary>
            [Description("Terça-Feira")]
            Terca = 2,

            /// <summary> Quarta-Feira: quarto dia da semana </summary>
            [Description("Quarta-Feira")]
            Quarta = 3,

            /// <summary> Quinta-Feira: quinto dia da semana </summary>
            [Description("Quinta-Feira")]
            Quinta = 4,

            /// <summary> Sexta-Feira: sexto dia da semana </summary>
            [Description("Sexta-Feira")]
            Sexta = 5,

            /// <summary> Sábado: sétimo dia da semana </summary>
            [Description("Sábado")]
            Sábado = 6
        }

        public enum eTipoPagamento
        {
            [Description("Dinheiro")]
            Dinheiro = 0,
            [Description("Cartão de Débito")]
            CartaoDebito = 1,
            [Description("Cartão de Crédito")]
            CartaCredito = 2,
            [Description("Cheque")]
            Cheque = 3,
            [Description("Outros")]
            Outros = 9
        }

        public enum eTipoAtendimento
        {
            [Description("Venda")]
            Venda = 0,
            [Description("Orçamento")]
            Orcamento = 1
        }

        /// <summary>
        /// Obtém a descrição de um determinado Enumerador.
        /// Tenta retornar a descrição indicada por Description (ComponentModel) e caso não exista, retorna o proprio nome do Enumerador
        /// </summary>
        /// <param name="e">Enumerador que terá a descrição obtida.</param>
        /// <returns>String com a descrição do Enumerador.</returns>
        public static string EnumDescription(Enum e)
        {
            Type t = e.GetType();
            DescriptionAttribute[] att = { };

            if (Enum.IsDefined(t, e))
            {
                FieldInfo fieldInfo = t.GetField(e.ToString());
                att = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            }
            return (att.Length > 0 ? att[0].Description ?? "Nulo" : e.ToString());
        }
    }
}
