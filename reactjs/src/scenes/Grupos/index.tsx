import AppComponentBase from 'src/components/AppComponentBase';
import { inject, observer } from 'mobx-react';
import Stores from 'src/stores/storeIdentifier';
import GrupoStore from 'src/stores/grupoStore';
import * as React from 'react';
import { Card, Row, Col, Button, Table } from 'antd';
import { GetGruposOutput } from 'src/services/grupo/dto/getGruposOutput';
import { GetGrupoInput } from 'src/services/grupo/dto/getGrupoInput';
import CreateGrupo from 'src/scenes/Grupos/componentes/createGrupo';
import AlumnosGrupo from 'src/scenes/Grupos/componentes/alumnosGrupo';
import InscribirAlumno from 'src/scenes/Grupos/componentes/inscribirAlumno';
import CalificarGrupo from 'src/scenes/Grupos/componentes/calificarGrupo';
import { AbrirGrupoInput } from 'src/services/grupo/dto/abrirGrupoInput';
import { AlumnoInscrito } from 'src/models/Grupo/GrupoModel';
import { InscribirAlumnoInput } from 'src/services/grupo/dto/inscribirAlumnoInput';
import { CalificarGrupoInput } from 'src/services/grupo/dto/calificarGrupoInput';
import { KeyValuePair } from 'src/services/dto/keyValuePair';
//import { CalificarGrupoInput } from 'src/services/grupo/dto/calificarGrupoInput';

export interface IGruposProps {
  grupoStore: GrupoStore;
}

export interface IGruposState {
  modalVisible: number;
  maxResultCount: number;
  skipCount: number;
  grupoId: string;
  filter: string;
  materias: { [key: string]: GetAllMateriasOutput[] };
  alumnos: GetAlumnosOutput[];
  alumnosInscritos: AlumnoInscrito[];
}

@inject(Stores.GrupoStore)
@observer
class Grupos extends AppComponentBase<IGruposProps, IGruposState> {
  formRef: any;
  createFormRef: any;
  alumnoAddFormRef: any;
  calificarFormRef: any;

  state = {
    modalVisible: 0,
    maxResultCount: 10,
    skipCount: 0,
    grupoId: '',
    filter: '',
    materias: {},
    alumnos: [],
    alumnosInscritos: [],
  };

  async componentDidMount() {
    await this.getAll();
  }

  async getAll() {
    await this.props.grupoStore.getAll();
  }

  Modal = (modalId: number) => {
    this.setState({
      modalVisible: modalId,
    });
  };

  async createOrUpdateModalOpen(getGrupoInput: GetGrupoInput) {
    if (getGrupoInput.id == '0') {
      await this.props.grupoStore.nuevoGrupo();
    } else {
      await this.props.grupoStore.get(getGrupoInput);
    }

    await this.props.grupoStore.getMaterias();
    this.setState({ materias: this.props.grupoStore.materias });

    this.setState({ grupoId: getGrupoInput.id });
    this.Modal(1);

    if (getGrupoInput.id != '0') {
      this.createFormRef.props.form.setFieldsValue({ ...this.props.grupoStore.grupoModel });
    }
  }

  async alumnosGrupoModelOpen(getGrupoInput: GetGrupoInput) {
    await this.props.grupoStore.get(getGrupoInput);
    await this.props.grupoStore.getAlumnos();

    this.setState({ alumnos: this.props.grupoStore.alumnos });
    this.setState({ alumnosInscritos: this.props.grupoStore.grupoModel.alumnosInscritos });

    this.setState({ grupoId: getGrupoInput.id });
    this.Modal(2);

    //this.formRef.props.form.setFieldsValue({ ...this.props.grupoStore.grupoModel });
  }

  async InscribirAlumnoModalOpen(getGrupoInput: GetGrupoInput) {
    const form = this.alumnoAddFormRef.props.form;
    form.resetFields();

    await this.props.grupoStore.get(getGrupoInput);
    await this.props.grupoStore.getAlumnos();

    this.setState({ alumnos: this.props.grupoStore.alumnos });
    this.setState({ alumnosInscritos: this.props.grupoStore.grupoModel.alumnosInscritos });

    this.setState({ grupoId: getGrupoInput.id });
    this.Modal(3);

    //this.alumnoAddFormRef.props.form.setFieldsValue({ ...this.props.grupoStore.grupoModel });
  }

  async CalificarGrupoModalOpen(getGrupoInput: GetGrupoInput) {
    const form = this.calificarFormRef.props.form;
    form.resetFields();

    await this.props.grupoStore.get(getGrupoInput);
    this.setState({ alumnosInscritos: this.props.grupoStore.grupoModel.alumnosInscritos });

    this.setState({ grupoId: getGrupoInput.id });
    this.Modal(4);

    //this.formRef.props.form.setFieldsValue({ ...this.props.grupoStore.grupoModel });
  }

  handleCreate = () => {
    const form = this.createFormRef.props.form;

    form.validateFields(async (err: any, values: any) => {
      if (err) {
        return;
      } else {
        if (this.state.grupoId == '0') {
          console.log(values);
          const data: AbrirGrupoInput = {
            materiaId: values.mat,
            capacidad: values.cap,
            horario: {
              lunes: values.dias.includes('Lunes'),
              martes: values.dias.includes('Martes'),
              miercoles: values.dias.includes('Miercoles'),
              jueves: values.dias.includes('Jueves'),
              viernes: values.dias.includes('Viernes'),
              hora: values.hor,
            },
          };
          await this.props.grupoStore.abrirGrupo(data);
          console.log(data);
        } else {
          //await this.props.grupoStore.actualizarGrupo({ id: this.state.GrupoId, ...values });
        }
      }

      await this.getAll();
      this.setState({ modalVisible: 0 });
      form.resetFields();
    });
  };

  handleAlumnoAdd = () => {
    const form = this.alumnoAddFormRef.props.form;

    form.validateFields(async (err: any, values: any) => {
      if (err) {
        return;
      } else {
        console.log(values);
        const data: InscribirAlumnoInput = {
          grupoId: this.state.grupoId,
          alumnoMatricula: values.mat,
        };
        await this.props.grupoStore.inscribirAlumno(data);
        console.log(data);
      }

      await this.getAll();
      this.setState({ modalVisible: 0 });
      form.resetFields();
    });
  };

  handleCalificar = () => {
    const form = this.calificarFormRef.props.form;

    form.validateFields(async (err: any, values: any) => {
      if (err) {
        return;
      } else {
        const keys = Object.keys(values).map(x => new KeyValuePair(x, values[x]));
        const data: CalificarGrupoInput = {
          grupoId: this.state.grupoId,
          calificaciones: keys,
        };
        await this.props.grupoStore.calificarGrupo(data);
        console.log(data);
      }

      await this.getAll();
      this.setState({ modalVisible: 0 });
      form.resetFields();
    });
  };

  saveFormRef = (formRef: any) => {
    this.formRef = formRef;
  };

  saveCreateFormRef = (formRef: any) => {
    this.createFormRef = formRef;
  };

  saveAlumnoAddFormRef = (formRef: any) => {
    this.alumnoAddFormRef = formRef;
  };

  saveCalificarFormRef = (formRef: any) => {
    this.calificarFormRef = formRef;
  };

  public render() {
    const { grupos } = this.props.grupoStore;
    const columns = [
      { title: 'ID', dataIndex: 'id', key: 'id', width: 80, render: (text: string) => <div>{text}</div> },
      { title: 'Materia', dataIndex: 'materia', key: 'materia', width: 150, render: (text: string) => <div>{text}</div> },
      { title: 'Capacidad', dataIndex: 'capacidad', key: 'capacidad', width: 150, render: (text: string) => <div>{text}</div> },
      { title: 'Horario', dataIndex: 'horario', key: 'horario', width: 150, render: (text: string) => <div>{text}</div> },
      { title: 'Alumnos Inscritos', dataIndex: 'alumnosInscritos', key: 'alumnosInscritos', width: 150, render: (text: string) => <div>{text}</div> },
      {
        title: 'Acción',
        width: 220,
        render: (text: string, item: GetGruposOutput) => (
          <div>
            <Button style={{ marginRight: 5 }} type="primary" icon="user" onClick={() => this.alumnosGrupoModelOpen({ id: item.id })}>
              {'Alumnos'}
            </Button>
            <Button style={{ marginRight: 5 }} type="primary" icon="edit" onClick={() => this.InscribirAlumnoModalOpen({ id: item.id })}>
              {'Inscribir'}
            </Button>
            <Button type="primary" icon="book" onClick={() => this.CalificarGrupoModalOpen({ id: item.id })}>
              {'Calificar'}
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
            <h2>{'Grupos'}</h2>
          </Col>
          <Col
            xs={{ span: 14, offset: 0 }}
            sm={{ span: 15, offset: 0 }}
            md={{ span: 15, offset: 0 }}
            lg={{ span: 1, offset: 21 }}
            xl={{ span: 1, offset: 21 }}
            xxl={{ span: 1, offset: 21 }}
          >
            <Button type="primary" shape="circle" icon="plus" onClick={() => this.createOrUpdateModalOpen({ id: '0' })} />
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
              rowKey={(record: GetGruposOutput) => record.id}
              size={'default'}
              bordered={true}
              columns={columns}
              pagination={{ pageSize: 100, total: grupos == undefined ? 0 : grupos.totalCount, defaultCurrent: 1 }}
              loading={grupos == undefined ? true : false}
              dataSource={grupos == undefined ? [] : grupos.items}
            />
          </Col>
        </Row>
        <CreateGrupo
          wrappedComponentRef={this.saveCreateFormRef}
          visible={this.state.modalVisible == 1}
          onCancel={() =>
            this.setState({
              modalVisible: 0,
            })
          }
          modalType={this.state.grupoId == '0' ? 'edit' : 'create'}
          onCreate={this.handleCreate}
          materias={this.state.materias}
        />
        <AlumnosGrupo
          wrappedComponentRef={this.saveFormRef}
          visible={this.state.modalVisible == 2}
          onCancel={() =>
            this.setState({
              modalVisible: 0,
            })
          }
          modalType={this.state.grupoId == '0' ? 'edit' : 'create'}
          grupoStore={this.props.grupoStore}
          alumnos={this.state.alumnos}
          alumnosInscritos={this.state.alumnosInscritos}
        />
        <InscribirAlumno
          wrappedComponentRef={this.saveAlumnoAddFormRef}
          visible={this.state.modalVisible == 3}
          onCancel={() =>
            this.setState({
              modalVisible: 0,
            })
          }
          onAlumnoAdd={this.handleAlumnoAdd}
          modalType={this.state.grupoId == '0' ? 'edit' : 'create'}
          alumnos={this.state.alumnos}
        />
        <CalificarGrupo
          wrappedComponentRef={this.saveCalificarFormRef}
          visible={this.state.modalVisible == 4}
          onCancel={() =>
            this.setState({
              modalVisible: 0,
            })
          }
          modalType={this.state.grupoId == '0' ? 'edit' : 'create'}
          alumnosInscritos={this.state.alumnosInscritos}
          onCalificar={this.handleCalificar}
        />
      </Card>
    );
  }
}

export default Grupos;
