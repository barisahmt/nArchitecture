﻿using System.Security.Principal;
using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Technology :Entity
{
    public int ProgrammingLanguageId { get; set; }
    public string Name { get; set; }
    public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

    public Technology(int id, int programmingLanguageId, string name, ProgrammingLanguage? programmingLanguage) : base(id)
    {
        ProgrammingLanguageId = programmingLanguageId;
        Name = name;
        ProgrammingLanguage = programmingLanguage;
    }