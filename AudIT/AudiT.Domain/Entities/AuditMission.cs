﻿using System.Diagnostics;
using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

/// <summary>
/// This class models the core operation of this application : an audit  mission
/// </summary>
public class AuditMission : AuditableEntity
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public User User { get; private set; }

    public string UserId { get; private set; }

    public Department Department { get; private set; }

    public AuditMissionStatus Status { get; private set; } = AuditMissionStatus.Creata;

    public Guid DepartmentId { get; private set; }

    public List<Entities.Activity> Actions { get; private set; } = new List<Activity>();

    public List<AuditMissionDocument> AuditMissionDocuments { get; private set; } = [];

    public List<AuditMissionObjectives> AuditMissionObjectives { get; private set; } = [];

    public AuditMission()
    {
    }


    private AuditMission(
        string name,
        User user,
        Guid userId,
        Department department,
        Guid departmentId
    )
    {
        Name = name;
        User = user;
        UserId = userId.ToString();
        Department = department;
        DepartmentId = departmentId;
    }


    public static Result<AuditMission> Create(
        string name,
        User user,
        Guid userId,
        Department department,
        Guid departmentId
    )
    {
        //TODO : Add validation logic here

        return Result<AuditMission>.Success(new AuditMission(name, user, userId, department, departmentId));
    }

    public void Update(
        string name,
        Department department,
        Guid departmentId,
        AuditMissionStatus status
    )
    {
        //TODO : Add validation logic here
        Status = status;
        Name = name;
        Department = department;
        DepartmentId = departmentId;
    }
}

public enum AuditMissionStatus
{
    Creata,
    PregatireaMisiunii,
    InterventiaLaFataLocului,
    RezultateleMisiunii,
    UrmarireaRecomandarilor,
    Finalizata,
    Arhivata,
    Anulata
}