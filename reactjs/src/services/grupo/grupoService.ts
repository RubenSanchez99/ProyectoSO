import { AbrirGrupoInput } from './dto/abrirGrupoInput';
import http from '../httpService';
import { InscribirAlumnoInput } from './dto/inscribirAlumnoInput';
import { CalificarGrupoInput } from './dto/calificarGrupoInput';
import { FinalizarGrupoInput } from './dto/finalizarGrupoInput';
import { GetGrupoInput } from './dto/getGrupoInput';
import { GetGruposOutput } from './dto/getGruposOutput';
import { PagedResultDto } from '../dto/pagedResultDto';
import GrupoModel from 'src/models/Grupo/GrupoModel';

class GrupoService {
  public async abrir(abrirGrupoInput: AbrirGrupoInput) {
    let result = await http.post('api/services/app/Grupo/AbrirGrupo', abrirGrupoInput);
    return result.data.result;
  }

  public async inscribirAlumno(inscribirAlumnoInput: InscribirAlumnoInput) {
    let result = await http.post('api/services/app/Grupo/InscribirAlumno', inscribirAlumnoInput);
    return result.data.result;
  }

  public async calificar(calificarGrupoInput: CalificarGrupoInput) {
    let result = await http.post('api/services/app/Grupo/CalificarGrupo', calificarGrupoInput);
    return result.data.result;
  }

  public async finalizar(finalizarGrupoInput: FinalizarGrupoInput) {
    let result = await http.post('api/services/app/Grupo/FinalizarGrupo', finalizarGrupoInput);
    return result.data.result;
  }

  public async getGrupos(): Promise<PagedResultDto<GetGruposOutput>> {
    let result = await http.get('api/services/app/Grupo/GetGrupos');
    return result.data.result;
  }

  public async getGrupo(getGrupoInput: GetGrupoInput): Promise<GrupoModel> {
    let result = await http.get('api/services/app/User/GetGrupo', { params: getGrupoInput });
    return result.data.result;
  }
}

export default new GrupoService();
