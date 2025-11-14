using System.Runtime.Serialization;

namespace EUNOIA.Enums
{
    /// <summary>
    /// Enum de ações sugeridas com base no feedback.
    /// </summary>
    public enum SuggestedAction
    {
        /// <summary>
        /// Sugere uma pausa curta para descanso rápido.
        /// </summary>
        [EnumMember(Value = "Pausa Curta")]
        PausaCurta = 1,

        /// <summary>
        /// Sugere uma pausa longa para descanso mais prolongado.
        /// </summary>
        [EnumMember(Value = "Pausa Longa")]
        PausaLonga = 2,

        /// <summary>
        /// Sugere uma reunião com o setor de Recursos Humanos.
        /// </summary>
        [EnumMember(Value = "Reunião RH")]
        ReuniaoRH = 3,

        /// <summary>
        /// Sugere considerar férias para o colaborador.
        /// </summary>
        [EnumMember(Value = "Considerar Férias")]
        ConsiderarFerias = 4,

        /// <summary>
        /// Sugere revisão da carga de trabalho.
        /// </summary>
        [EnumMember(Value = "Revisão de Carga")]
        RevisaoCarga = 5,

        /// <summary>
        /// Sugere suporte técnico para resolução de problemas.
        /// </summary>
        [EnumMember(Value = "Suporte Técnico")]
        SuporteTecnico = 6,

        /// <summary>
        /// Sugere treinamento de soft skills.
        /// </summary>
        [EnumMember(Value = "Treinamento Soft Skill")]
        TreinamentoSoftSkill = 7,

        /// <summary>
        /// Sugere a prática de atividade física.
        /// </summary>
        [EnumMember(Value = "Atividade Física")]
        AtividadeFisica = 8,

        /// <summary>
        /// Sugere consulta psicológica para apoio emocional.
        /// </summary>
        [EnumMember(Value = "Consulta Psicológica")]
        ConsultaPsicologica = 9,

        /// <summary>
        /// Sugere feedback do gestor.
        /// </summary>
        [EnumMember(Value = "Feedback Gestor")]
        FeedbackGestor = 10
    }
}
