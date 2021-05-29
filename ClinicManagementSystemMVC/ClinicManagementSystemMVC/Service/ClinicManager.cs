using ClinicManagementSystemMVC.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystemMVC.Service
{
    public class ClinicManager : ILogin<UserLogin>, IFunction<DocDetails>, IFunction<PatientDetails>, IFunction<Appointment>
    {
        private ClinicalDetailsContext _context;
        private ILogger<ClinicManager> _logger;

        public ClinicManager()
        {

        }
        public ClinicManager(ClinicalDetailsContext context, ILogger<ClinicManager> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(DocDetails t)
        {
            _context.DocTable.Add(t);
            _context.SaveChanges();
        }

        public void Add(PatientDetails t)
        {
            _context.PatientTable.Add(t);
            _context.SaveChanges();
        }

        public void Add(Appointment t)
        {
            throw new NotImplementedException();
        }

        public void Add(UserLogin t)
        {
            throw new NotImplementedException();
        }

        public DocDetails Get(int id)
        {
            try
            {
                DocDetails doctor = _context.DocTable.FirstOrDefault(a => a.DoctorID == id);
                return doctor;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<UserLogin> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool SignIn(UserLogin t)
        {
            try
            {
                UserLogin login = _context.LoginTable.SingleOrDefault(u => u.Username == t.Username);
                if (login.Password == t.Password)
                    return true;
            }
            catch (Exception)
            {

                return false;
            }
            return false;
        }

        public int UserLogin(UserLogin t)
        {
            throw new NotImplementedException();
        }

        PatientDetails IFunction<PatientDetails>.Get(int id)
        {
            try
            {
                PatientDetails patient = _context.PatientTable.FirstOrDefault(a => a.PatientID == id);
                return patient;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        Appointment IFunction<Appointment>.Get(int id)
        {
            try
            {
                Appointment appointment = _context.AppointmentTable.FirstOrDefault(a => a.AppointmentId == id);
                return appointment;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }
    }
}

