using System.Runtime.Serialization;

namespace EUNOIA.Enums
{
    /// <summary>
    /// Enum de ações sugeridas com base no feedback.
    /// </summary>
    public enum SuggestedAction
    {
        [EnumMember(Value = "Pausa Curta")]
        PausaCurta = 1,

        [EnumMember(Value = "Pausa Longa")]
        PausaLonga = 2,

        [EnumMember(Value = "Reunião RH")]
        ReuniaoRH = 3,

        [EnumMember(Value = "Considerar Férias")]
        ConsiderarFerias = 4,

        [EnumMember(Value = "Revisão de Carga")]
        RevisaoCarga = 5,

        [EnumMember(Value = "Suporte Técnico")]
        SuporteTecnico = 6,

        [EnumMember(Value = "Treinamento Soft Skill")]
        TreinamentoSoftSkill = 7,

        [EnumMember(Value = "Atividade Física")]
        AtividadeFisica = 8,

        [EnumMember(Value = "Consulta Psicológica")]
        ConsultaPsicologica = 9,

        [EnumMember(Value = "Feedback Gestor")]
        FeedbackGestor = 10
    }
}
