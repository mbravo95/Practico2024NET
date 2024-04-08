using Practico2024NET.Domain;
using Practico2024NET.Exceptions;
using Practico2024NET.Repository;

namespace Practico2024NET.Service
{
    public class SportService : ISportService
    {
        private readonly ISportRepository _portRepository;

        public SportService(ISportRepository portRepository)
        {
            _portRepository = portRepository;
        }

        public void addSport(string sport_name)
        {
            if (_portRepository.SportNameExists(sport_name)) throw new RecordDuplicatedException("El deporte " + sport_name + " ya existe en el sistema");
            _portRepository.AddSport(new Sport { name = sport_name });
        }

        public void deleteSport(int id)
        {
            if (!_portRepository.SportExists(id)) throw new RecordNotFoundException("El deporte con id=" + id + " no existe");
            _portRepository.DeleteSport(id);
        }

        public string getSport(int id)
        {
            var sport = _portRepository.GetSport(id);
            if (sport == null) throw new RecordNotFoundException("El deporte con id=" + id + " no existe");
            return sport.name;
        }

        public IEnumerable<string> getSports()
        {
            return convertSportsToString(_portRepository.GetSports());
        }

        public void updateSport(int id, string sport_name)
        {
            var sport = _portRepository.GetSport(id);
            if (sport == null) throw new RecordNotFoundException("El deporte con id=" + id + " no existe");
            if (_portRepository.SportNameExists(sport_name)) throw new RecordDuplicatedException("El deporte " + sport_name + " ya existe en el sistema");
            sport.name = sport_name;
            _portRepository.UpdateSport(sport);
        }

        private IEnumerable<string> convertSportsToString(IEnumerable<Sport> sports)
        {
            IEnumerable<string> result = new List<string>();
            foreach (Sport s in sports)
            {
                result.Append(s.name);
            }
            return result;
        }
    }
}
