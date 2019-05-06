import * as React from 'react';
import { Modal, Row, Col, Table } from 'antd';
//import FormItem from 'antd/lib/form/FormItem';
import { MateriaInscrita } from 'src/models/Alumno/AlumnoModel';
//import rules from './createOrUpdateGrupo.validation';

export interface IHorarioProps {
  materias: MateriaInscrita[] | undefined;
  visible: boolean;
  onCancel: () => void;
  modalType: string;
}

class Kardex extends React.Component<IHorarioProps> {
  render() {
    const columns = [
      { title: 'Materia', dataIndex: 'materia.nombre', key: 'materia', width: 220, render: (text: string) => <div>{text}</div> },
      { title: 'Calificacion', dataIndex: 'calificacion', key: 'calificacion', width: 80, render: (text: string) => <div>{text}</div> },
    ];

    const { visible, onCancel } = this.props;

    return (
      <Modal visible={visible} cancelText={'Cerrar'} onCancel={onCancel} title={'Kárdex'}>
        <Row>
          <Col
            xs={{ span: 24, offset: 0 }}
            sm={{ span: 24, offset: 0 }}
            md={{ span: 24, offset: 0 }}
            lg={{ span: 24, offset: 0 }}
            xl={{ span: 24, offset: 0 }}
            xxl={{ span: 24, offset: 0 }}
          >
            <Table
              rowKey={(record: MateriaInscrita) => record.materiaId.toString()}
              size={'default'}
              bordered={true}
              columns={columns}
              loading={this.props.materias == undefined ? true : false}
              dataSource={this.props.materias == undefined ? [] : this.props.materias}
            />
          </Col>
        </Row>
      </Modal>
    );
  }
}

export default Kardex;
