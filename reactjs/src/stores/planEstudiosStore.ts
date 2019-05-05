import { observable, action } from 'mobx';
import { PagedResultDto } from 'src/services/dto/pagedResultDto';
import materiaService from 'src/services/materia/materiaService';

class PlanEstudiosStore {
  @observable materias: PagedResultDto<GetAllMateriasOutput>;

  @action
  async getAll() {
    let result = await materiaService.getAll();
    this.materias = result;
  }
}

export default PlanEstudiosStore;
