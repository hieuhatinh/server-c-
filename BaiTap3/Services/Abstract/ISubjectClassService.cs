using BaiTap3.Dtos.SubjectClass;
using BaiTap3.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap3.Services.Abstract
{
    public interface ISubjectClassService
    {
        SubjectClass CreateSubjectClass(CreateSubjectClassDto input);

        void UpdateSubjectClass(int id, [FromBody] UpdateSubjectClassDto input);

        SubjectClass GetSubjectClass(int id);

        List<SubjectClass> GetAllSubjectClasses();
        void DeleteSubjectClass(int idClass);
    }
}
