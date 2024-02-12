// See https://aka.ms/new-console-template for more information


using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using AudIT.Infrastructure;
using Microsoft.EntityFrameworkCore;

var db = new AudITContext();

var inst = Institution.Create(
    "asdasd",
    "asdasd",
    "asdasd"
).Value;


var depart = Department.Create(
    "asdasd",
    "asdasd",
    "asdasd",
    institution: inst
).Value;

var user = AudiT.Domain.Entities.User.Create(
    "asdasd",
    "asdasd",
    "asdasd",
    "asdasd",
    "asdasd",
    "asdasd",
    "asdasd",
    depart
).Value;


var temp_doc = TemplateDocument.Create(
    "asdasd",
    "asdasd",
    user,
    user.Id,
    DocumentState.Draft,
    TemplateType.Excel,
    1
).Value;


var st_doc = StandaloneDocument.Create(
    "standalone",
    "asdasd",
    user,
    user.Id,
    depart,
    depart.Id
).Value;


//
// db.Add(inst);
// db.Add(depart);
// db.Add(user);
db.Add(temp_doc);

db.Add(st_doc);
db.SaveChanges();
//
// //get all the documents
// var standaloneDocuments = db.StandaloneDocuments.ToList();
// var templateDocuments = db.TemplateDocuments.ToList();
//
// Console.WriteLine("Standalone Documents:" + standaloneDocuments[0].Name);
// // Console.WriteLine("Template Documents:" + templateDocuments[0].Name);



// var auditMission = AuditMission.Create(
//     "asdasd123",
//     user,
//     user.Id,
//     depart,
//     depart.Id
// ).Value;
//
// var auditMissionDocument =   AuditMissionDocument.Create(
//     auditMission,
//     st_doc
// ).Value;
//
// var auditMissionDocument2 =   AuditMissionDocument.Create(
//     auditMission,
//     temp_doc
// ).Value;
//
//
// auditMission.AuditMissionDocuments.Add(auditMissionDocument);
// auditMission.AuditMissionDocuments.Add(auditMissionDocument2);
// //
// //
// db.Add(auditMission);
// db.SaveChanges();


//retrieve the audit mission

var auditMission_db = db.AuditMissions.
    Include(auditMission1 => auditMission1.AuditMissionDocuments).
    ThenInclude(baseDocument => baseDocument.BaseDocument).First();

Console.WriteLine("Audit Mission:" + auditMission_db.Name);
foreach (var doc in auditMission_db.AuditMissionDocuments)
{
    Console.WriteLine("Audit Mission Document:" + doc.BaseDocument.Name);
}