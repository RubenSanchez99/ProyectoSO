import { PagedResultDto } from '../dto/pagedResultDto';
import http from '../httpService';

class MateriaService {
  public async getAll(): Promise<PagedResultDto<GetAllMateriasOutput>> {
    let result = await http.get('api/services/app/Materia/GetAll', { params: { maxResultCount: 100 } });
    return result.data.result;
  }
}

export default new MateriaService();
