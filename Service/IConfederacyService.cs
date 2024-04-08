using Practico2024NET.Dtos;

namespace Practico2024NET.Service
{
    public interface IConfederacyService
    {
        IEnumerable<ConfederacyDto> getConfederacies();
        ConfederacyDto getConfederacy(int id);
        void addConfederacy(ConfederacyCreateOrUpdateDto confederacy);
        void deleteConfederacy(int id);
        void updateConfederacy(int id, ConfederacyCreateOrUpdateDto confederacy);
    }
}
