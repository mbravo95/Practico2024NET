using Practico2024NET.Domain;
using Practico2024NET.Dtos;
using Practico2024NET.Repository;
using Practico2024NET.Exceptions;

namespace Practico2024NET.Service
{
    public class ConfederacyService : IConfederacyService
    {
        private readonly IConfederacyRepository _confederacyRepository;

        public ConfederacyService(IConfederacyRepository confederacyRepository)
        {
            _confederacyRepository = confederacyRepository;
        }

        public void addConfederacy(ConfederacyCreateOrUpdateDto confederacy)
        {
            if (_confederacyRepository.ConfederacyNameExists(confederacy.Name)) throw new RecordDuplicatedException("Ya existe una confederacion con el nombre " + confederacy.Name);
            _confederacyRepository.AddConfederacy(new Confederacy
            {
                name = confederacy.Name,
                creation_date = confederacy.creation_date
            });
        }

        public void deleteConfederacy(int id)
        {
            if (!_confederacyRepository.ConfederacyExists(id)) throw new RecordNotFoundException("La conferedacion con id=" + id + " no existe");
            _confederacyRepository.DeleteConfederacy(id);
        }

        public IEnumerable<ConfederacyDto> getConfederacies()
        {
            return confederaciesToListDto(_confederacyRepository.GetConfederacies());
        }

        public ConfederacyDto getConfederacy(int id)
        {
            var confederacy1 = _confederacyRepository.GetConfederacy(id);
            if (confederacy1 == null) throw new RecordNotFoundException("La confederacion " + id + " no existe");
            return mapDtoToEntity(confederacy1);
        }

        public void updateConfederacy(int id, ConfederacyCreateOrUpdateDto confederacy)
        {
            var confederacy1 = _confederacyRepository.GetConfederacy(id);
            if (confederacy1 == null) throw new RecordNotFoundException("La confederacion " + id + " no existe");
            if (_confederacyRepository.ConfederacyNameExists(confederacy.Name)) throw new RecordDuplicatedException("Ya existe una confederacion con el nombre " + confederacy.Name);
            confederacy1.name = confederacy.Name;
            confederacy1.creation_date = confederacy.creation_date;
            _confederacyRepository.UpdateConfederacy(confederacy1);
        }

        private IEnumerable<ConfederacyDto> confederaciesToListDto(IEnumerable<Confederacy> confederacies)
        {
            IEnumerable<ConfederacyDto> result = new List<ConfederacyDto>();
            foreach (Confederacy c in confederacies)
            {
                result.Append(mapDtoToEntity(c));
            }
            return result;
        }

        private ConfederacyDto mapDtoToEntity(Confederacy c)
        {
            return new ConfederacyDto
            {
                Id = c.id,
                Name = c.name,
                Creation_date = c.creation_date
            };
        }
    }
}
