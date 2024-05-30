using DataAccessLayer.Command.GradeCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IGradeRepository
    {
        IEnumerable<GetGrades> GetAllGrades();
        Task<GetGrade> GetGradeById(int id); 
    }
}
