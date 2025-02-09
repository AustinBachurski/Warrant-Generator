﻿using WarrantGenerator.DTOs;

namespace WarrantGenerator.Interfaces;

public interface IFacebookData
{
    public string Account { get; }
    public string CertainAccounts { get; }
    public string CourtDistrict { get; }
    public string CrimeGrammar { get; }
    public string EmploymentDuration { get; }
    public string EmploymentDurationType { get; }
    public string Individual { get; }
    public string IsOrAre { get; }
    public string LegalCriteriaForOffenses { get; }
    public string OfficerName { get; }
    public string OfficerRank { get; }
    public string OfficerSubjectivePronoun { get; }
    public string OfficerPosessivePronoun { get; }
    public string OutputFile { get; }
    public string ProbableCause { get; }
    public string StartDate { get; }
    public string TodaysDate { get; }

    public bool GenerateApplicationDocument { get; }
    public bool GenerateWarrantDocument { get; }
    public bool RequestToSeal { get; }
    public bool RequestToDelayNotification { get; }

    public MCACrime[] Crimes { get; }
    public SocialMediaProfile[] Profiles { get; }

}

