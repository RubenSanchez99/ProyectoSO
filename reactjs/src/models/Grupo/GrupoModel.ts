class GrupoModel {
  materiaId: number;
  capacidad: number;
  horario: Horario;
  finalizado: boolean;
  alumnosInscritos: AlumnoInscrito[];
}

class Horario {}

class AlumnoInscrito {
  matricula: number;
  nombre: string;
  calificacion?: number;
}

export default GrupoModel;
