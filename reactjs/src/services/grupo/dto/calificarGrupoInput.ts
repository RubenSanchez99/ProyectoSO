import { KeyValuePair } from 'src/services/dto/keyValuePair';

export interface CalificarGrupoInput {
  grupoId: string;
  calificaciones: KeyValuePair[];
}
