﻿using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Interfaces;

namespace HealthCare.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDoctorRepository Doctors { get; }
        public IPatientRepository Patients { get; }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context, IDoctorRepository doctors , IPatientRepository patients)
        {
            _context = context;
            Doctors = doctors;
            Patients = patients;
        }
        public int Compelete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
