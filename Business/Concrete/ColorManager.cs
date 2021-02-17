using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal _colorDal)
        {
           this._colorDal = _colorDal;
        }
        public void Add(Color color)
        {
            _colorDal.Add(color);
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.getAll();
        }

        public Color GetById(int Id)
        {
            return _colorDal.Get(p => p.Id == Id);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
        }
    }
}
