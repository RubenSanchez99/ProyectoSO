import { observable, action } from 'mobx';
import { PagedResultDto } from 'src/services/dto/pagedResultDto';
import AlumnoModel from 'src/models/Alumno/AlumnoModel';
import alumnoService from 'src/services/alumno/alumnoService';
import { EntityDto } from 'src/services/dto/entityDto';
import CrearAlumnoInput from 'src/services/alumno/dto/crearAlumnoInput';

class AlumnoStore {
  @observable alumnos: PagedResultDto<GetAlumnosOutput>;
  @observable alumnoModel: AlumnoModel = new AlumnoModel();

  @action
  createAlumno() {
    this.alumnoModel = {
      nombre: '',
      apellidoPaterno: '',
      apellidoMaterno: '',
    };
  }

  @action
  async registrarAlumno(crearAlumnoInput: CrearAlumnoInput) {
    let result = await alumnoService.registrarAlumno(crearAlumnoInput);
    this.alumnos.items.push(result);
  }

  async actualizarAlumno(actualizarAlumnoInput: CrearAlumnoInput) {
    let result = await alumnoService.actualizarAlumno(actualizarAlumnoInput);
    this.alumnos.items = this.alumnos.items.map((x: GetAlumnosOutput) => {
      if (x.matricula == actualizarAlumnoInput.id) x = result;
      return x;
    });
  }

  async get(entityDto: EntityDto) {
    let result = await alumnoService.get(entityDto);
    this.alumnoModel = result;
  }

  async getAll() {
    let result = await alumnoService.getAll();
    this.alumnos = result;
  }
}

export default AlumnoStore;
