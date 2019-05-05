import http from '../httpService';
import { EntityDto } from '../dto/entityDto';
import { PagedResultDto } from '../dto/pagedResultDto';
import AlumnoModel from 'src/models/Alumno/AlumnoModel';
import CrearAlumnoInput from './dto/crearAlumnoInput';

class AlumnoService {
  public async registrarAlumno(crearAlumnoInput: CrearAlumnoInput) {
    let result = await http.post('api/services/app/Alumno/RegistrarAlumno', crearAlumnoInput);
    return result.data.result;
  }

  public async actualizarAlumno(actualizarAlumnoInput: CrearAlumnoInput) {
    let result = await http.post('api/services/app/Alumno/ActualizarInfoDeAlumno', actualizarAlumnoInput);
    return result.data.result;
  }

  public async get(entityDto: EntityDto): Promise<AlumnoModel> {
    let result = await http.get('api/services/app/Alumno/GetAlumno', { params: entityDto });
    return result.data.result;
  }

  public async getAll(): Promise<PagedResultDto<GetAlumnosOutput>> {
    let result = await http.get('api/services/app/Alumno/GetAlumnos');
    return result.data.result;
  }
}

export default new AlumnoService();
