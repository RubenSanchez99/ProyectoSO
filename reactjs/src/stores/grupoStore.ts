import { observable, action } from 'mobx';
import { GetGruposOutput } from 'src/services/grupo/dto/getGruposOutput';
import { PagedResultDto } from 'src/services/dto/pagedResultDto';
import GrupoModel, { AlumnoInscrito } from 'src/models/Grupo/GrupoModel';
import grupoService from 'src/services/grupo/grupoService';
import { GetGrupoInput } from 'src/services/grupo/dto/getGrupoInput';
import { FinalizarGrupoInput } from 'src/services/grupo/dto/finalizarGrupoInput';
import { CalificarGrupoInput } from 'src/services/grupo/dto/calificarGrupoInput';
import { InscribirAlumnoInput } from 'src/services/grupo/dto/inscribirAlumnoInput';
import { AbrirGrupoInput } from 'src/services/grupo/dto/abrirGrupoInput';
import materiaService from 'src/services/materia/materiaService';
import alumnoService from 'src/services/alumno/alumnoService';

var groupBy = function<TItem>(xs: TItem[], key: string): { [key: string]: TItem[] } {
  return xs.reduce(function(rv, x) {
    (rv[x[key]] = rv[x[key]] || []).push(x);
    return rv;
  }, {});
};

class GrupoStore {
  @observable grupos: PagedResultDto<GetGruposOutput>;
  @observable grupoModel: GrupoModel = new GrupoModel();
  @observable materias: { [key: string]: GetAllMateriasOutput[] };
  @observable alumnos: GetAlumnosOutput[];

  @action
  nuevoGrupo() {
    this.grupoModel = {
      materiaId: 0,
      capacidad: 0,
      horario: {
        lunes: false,
        martes: false,
        miercoles: false,
        jueves: false,
        viernes: false,
        hora: false,
      },
      finalizado: false,
      alumnosInscritos: [],
    };
  }

  @action
  async abrirGrupo(abrirGrupoInput: AbrirGrupoInput) {
    let result = await grupoService.abrir(abrirGrupoInput);
    this.grupos.items.push(result);
  }

  @action
  async inscribirAlumno(inscribirAlumnoInput: InscribirAlumnoInput) {
    let result = await grupoService.inscribirAlumno(inscribirAlumnoInput);
    this.grupos.items = this.grupos.items.map((x: GetGruposOutput) => {
      if (x.id == inscribirAlumnoInput.grupoId) x = result;
      return x;
    });

    this.grupoModel.alumnosInscritos.map((x: AlumnoInscrito) => {
      if (x.matricula == inscribirAlumnoInput.alumnoMatricula) x = result;
      return x;
    });
  }

  @action
  async calificarGrupo(calificarGrupoInput: CalificarGrupoInput) {
    let result = await grupoService.calificar(calificarGrupoInput);
    this.grupos.items = this.grupos.items.map((x: GetGruposOutput) => {
      if (x.id == calificarGrupoInput.grupoId) x = result;
      return x;
    });
  }

  @action
  async finalizarGrupo(finalizarGrupoInput: FinalizarGrupoInput) {
    let result = await grupoService.finalizar(finalizarGrupoInput);
    this.grupos.items = this.grupos.items.map((x: GetGruposOutput) => {
      if (x.id == finalizarGrupoInput.grupoId) x = result;
      return x;
    });
  }

  @action
  async get(getGrupoInput: GetGrupoInput) {
    let result = await grupoService.getGrupo(getGrupoInput);
    this.grupoModel = result;
  }

  @action
  async getAll() {
    let result = await grupoService.getGrupos();
    this.grupos = result;
  }

  @action
  async getMaterias() {
    let result = await materiaService.getAll();
    this.materias = groupBy(result.items, 'semestre');
  }

  @action
  async getAlumnos() {
    let result = await alumnoService.getAll();
    this.alumnos = result.items;
  }
}

export default GrupoStore;
