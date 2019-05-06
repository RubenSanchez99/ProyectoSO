class AlumnoModel {
  nombre: string;
  apellidoPaterno: string;
  apellidoMaterno: string;
  materiasInscritas?: MateriaInscrita[];
}

export class MateriaInscrita {
  materiaId: number;
  grupoId: number;
  calificacion?: number;
  materia: GetAllMateriasOutput;
  horario: string;
}

export default AlumnoModel;
