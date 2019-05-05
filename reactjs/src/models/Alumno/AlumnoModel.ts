class AlumnoModel {
  nombre: string;
  apellidoPaterno: string;
  apellidoMaterno: string;
  materiasInscritas?: MateriaInscrita[];
}

class MateriaInscrita {
  materiaId: number;
  grupoId: number;
  calificacion?: number;
}

export default AlumnoModel;
