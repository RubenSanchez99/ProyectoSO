import * as React from 'react';
import Form, { FormComponentProps } from 'antd/lib/form';
import { Modal, Row, Col, Table } from 'antd';
//import FormItem from 'antd/lib/form/FormItem';
import { AlumnoInscrito } from 'src/models/Grupo/GrupoModel';
import GrupoStore from 'src/stores/grupoStore';
//import rules from './createOrUpdateGrupo.validation';

export interface IAlumnosGrupoProps extends FormComponentProps {
  alumnos: GetAlumnosOutput[];
  alumnosInscritos: AlumnoInscrito[];
  visible: boolean;
  onCancel: () => void;
  modalType: string;
  grupoStore: GrupoStore;
}

class AlumnosGrupo extends React.Component<IAlumnosGrupoProps> {
  render() {
    const columns = [
      { title: 'Matrícula', dataIndex: 'matricula', key: 'matricula', width: 80, render: (text: string) => <div>{text}</div> },
      { title: 'Nombre', dataIndex: 'nombre', key: 'nombre', width: 220, render: (text: string) => <div>{text}</div> },
      { title: 'Calificación', dataIndex: 'calificacion', key: 'calificacion', width: 30, render: (text: string) => <div>{text}</div> },
    ];

    const { visible, onCancel } = this.props;

    return (
      <Modal visible={visible} cancelText={'Cerrar'} onCancel={onCancel} title={'Lista del Grupo'}>
        <Row style={{ marginTop: 20 }}>
          <Col
            xs={{ span: 24, offset: 0 }}
            sm={{ span: 24, offset: 0 }}
            md={{ span: 24, offset: 0 }}
            lg={{ span: 24, offset: 0 }}
            xl={{ span: 24, offset: 0 }}
            xxl={{ span: 24, offset: 0 }}
          >
            <Table
              rowKey={(record: AlumnoInscrito) => record.matricula.toString()}
              size={'default'}
              bordered={true}
              columns={columns}
              loading={this.props.alumnosInscritos == undefined ? true : false}
              dataSource={this.props.alumnosInscritos == undefined ? [] : this.props.alumnosInscritos}
            />
          </Col>
        </Row>
      </Modal>
    );
  }
}

export default Form.create()(AlumnosGrupo);
