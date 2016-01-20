using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSN.DAL;
namespace CSN.Business
{
    public interface IClass1
    {
        void test();
    }
    public class Class1 : IClass1
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public void test()
        {
            var state = unitOfWork.TblStatesRepository.Get();
            throw new NotImplementedException();
        }
    }
}
