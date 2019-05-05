import AppComponentBase from 'src/components/AppComponentBase';
import { inject, observer } from 'mobx-react';
import Stores from 'src/stores/storeIdentifier';
import AlumnoStore from 'src/stores/alumnoStore';
import { EntityDto } from 'src/services/dto/entityDto';
import * as React from 'react';
import { Card, Row, Col, Button, Table } from 'antd';
import CreateOrUpdateAlumno from './components/createOrUpdateAlumno';

export interface IAlumnosProps {
  alumnoStore: AlumnoStore;
}

export interface IAlumnosState {
  modalVisible: boolean;
  maxResultCount: number;
  skipCount: number;
  alumnoId: number;
  filter: string;
}

@inject(Stores.AlumnoStore)
@observer
class Alumnos extends AppComponentBase<IAlumnosProps, IAlumnosState> {
  formRef: any;

  state = {
    modalVisible: false,
    maxResultCount: 10,
    skipCount: 0,
    alumnoId: 0,
    filter: '',
  };

  async componentDidMount() {
    await this.getAll();
  }

  async getAll() {
    await this.props.alumnoStore.getAll();
  }

  Modal = () => {
    this.setState({
      modalVisible: !this.state.modalVisible,
    });
  };

  async createOrUpdateModalOpen(entityDto: EntityDto) {
    if (entityDto.id == 0) {
      await this.props.alumnoStore.createAlumno();
    } else {
      await this.props.alumnoStore.get(entityDto);
    }

    this.setState({ alumnoId: entityDto.id });
    this.Modal();

    this.formRef.props.form.setFieldsValue({ ...this.props.alumnoStore.alumnoModel });
  }

  handleCreate = () => {
    const form = this.formRef.props.form;

    form.validateFields(async (err: any, values: any) => {
      if (err) {
        return;
      } else {
        if (this.state.alumnoId == 0) {
          await this.props.alumnoStore.registrarAlumno(values);
        } else {
          await this.props.alumnoStore.actualizarAlumno({ id: this.state.alumnoId, ...values });
        }
      }

      await this.getAll();
      this.setState({ modalVisible: false });
      form.resetFields();
    });
  };

  saveFormRef = (formRef: any) => {
    this.formRef = formRef;
  };

  public render() {
    const { alumnos } = this.props.alumnoStore;
    const columns = [
      { title: 'Matrícula', dataIndex: 'matricula', key: 'matricula', width: 150, render: (text: string) => <div>{text}</div> },
      { title: 'Nombre', dataIndex: 'nombre', key: 'nombre', width: 150, render: (text: string) => <div>{text}</div> },
      { title: 'Materias en curso', dataIndex: 'materiasEnCurso', key: 'materiasEnCurso', width: 150, render: (text: string) => <div>{text}</div> },
      {
        title: 'Acción',
        width: 150,
        render: (text: string, item: GetAlumnosOutput) => (
          <div>
            <Button type="primary" icon="setting" onClick={() => this.createOrUpdateModalOpen({ id: parseInt(item.matricula) })}>
              {'Editar'}
            </Button>
          </div>
        ),
      },
    ];

    return (
      <Card>
        <Row>
          <Col
            xs={{ span: 4, offset: 0 }}
            sm={{ span: 4, offset: 0 }}
            md={{ span: 4, offset: 0 }}
            lg={{ span: 2, offset: 0 }}
            xl={{ span: 2, offset: 0 }}
            xxl={{ span: 2, offset: 0 }}
          >
            {' '}
            <h2>{'Alumnos'}</h2>
          </Col>
          <Col
            xs={{ span: 14, offset: 0 }}
            sm={{ span: 15, offset: 0 }}
            md={{ span: 15, offset: 0 }}
            lg={{ span: 1, offset: 21 }}
            xl={{ span: 1, offset: 21 }}
            xxl={{ span: 1, offset: 21 }}
          >
            <Button type="primary" shape="circle" icon="plus" onClick={() => this.createOrUpdateModalOpen({ id: 0 })} />
          </Col>
        </Row>
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
              rowKey={(record: GetAlumnosOutput) => record.matricula}
              size={'default'}
              bordered={true}
              columns={columns}
              pagination={{ pageSize: 10, total: alumnos == undefined ? 0 : alumnos.totalCount, defaultCurrent: 1 }}
              loading={alumnos == undefined ? true : false}
              dataSource={alumnos == undefined ? [] : alumnos.items}
            />
          </Col>
        </Row>
        <CreateOrUpdateAlumno
          wrappedComponentRef={this.saveFormRef}
          visible={this.state.modalVisible}
          onCancel={() =>
            this.setState({
              modalVisible: false,
            })
          }
          modalType={this.state.alumnoId == 0 ? 'edit' : 'create'}
          onCreate={this.handleCreate}
        />
      </Card>
    );
  }
}

export default Alumnos;
