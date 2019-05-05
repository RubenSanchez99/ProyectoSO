import AppComponentBase from 'src/components/AppComponentBase';
import { inject, observer } from 'mobx-react';
import Stores from 'src/stores/storeIdentifier';
import GrupoStore from 'src/stores/grupoStore';
import * as React from 'react';
import { Card, Row, Col, Button, Table } from 'antd';
import { GetGruposOutput } from 'src/services/grupo/dto/getGruposOutput';
import { GetGrupoInput } from 'src/services/grupo/dto/getGrupoInput';
import CreateGrupo from 'src/scenes/Grupos/componentes/createGrupo';

export interface IGruposProps {
  grupoStore: GrupoStore;
}

export interface IGruposState {
  modalVisible: boolean;
  maxResultCount: number;
  skipCount: number;
  grupoId: string;
  filter: string;
  materias: { [key: string]: GetAllMateriasOutput[] };
}

@inject(Stores.GrupoStore)
@observer
class Grupos extends AppComponentBase<IGruposProps, IGruposState> {
  formRef: any;

  state = {
    modalVisible: false,
    maxResultCount: 10,
    skipCount: 0,
    grupoId: '',
    filter: '',
    materias: {},
  };

  async componentDidMount() {
    await this.getAll();
  }

  async getAll() {
    await this.props.grupoStore.getAll();
  }

  Modal = () => {
    this.setState({
      modalVisible: !this.state.modalVisible,
    });
  };

  async createOrUpdateModalOpen(getGrupoInput: GetGrupoInput) {
    if (getGrupoInput.grupoId == '0') {
      await this.props.grupoStore.nuevoGrupo();
    } else {
      await this.props.grupoStore.get(getGrupoInput);
    }

    await this.props.grupoStore.getMaterias();
    this.setState({ materias: this.props.grupoStore.materias });

    this.setState;
    this.setState({ grupoId: getGrupoInput.grupoId });
    this.Modal();

    this.formRef.props.form.setFieldsValue({ ...this.props.grupoStore.grupoModel });
  }

  handleCreate = () => {
    const form = this.formRef.props.form;

    form.validateFields(async (err: any, values: any) => {
      if (err) {
        return;
      } else {
        if (this.state.grupoId == '0') {
          //await this.props.grupoStore.abrirGrupo(values);
          console.log(values);
        } else {
          //await this.props.grupoStore.actualizarGrupo({ id: this.state.GrupoId, ...values });
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
    const { grupos } = this.props.grupoStore;
    const columns = [
      { title: 'ID', dataIndex: 'id', key: 'id', width: 150, render: (text: string) => <div>{text}</div> },
      { title: 'Materia', dataIndex: 'materia', key: 'materia', width: 150, render: (text: string) => <div>{text}</div> },
      { title: 'Capacidad', dataIndex: 'capacidad', key: 'capacidad', width: 150, render: (text: string) => <div>{text}</div> },
      { title: 'Horario', dataIndex: 'horario', key: 'horario', width: 150, render: (text: string) => <div>{text}</div> },
      { title: 'Alumnos Inscritos', dataIndex: 'alumnosInscritos', key: 'alumnosInscritos', width: 150, render: (text: string) => <div>{text}</div> },
      {
        title: 'Acción',
        width: 150,
        render: (text: string, item: GetGruposOutput) => (
          <div>
            <Button type="primary" icon="setting" onClick={() => this.createOrUpdateModalOpen({ grupoId: item.id })}>
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
            <Button type="primary" shape="circle" icon="plus" onClick={() => this.createOrUpdateModalOpen({ grupoId: '0' })} />
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
          wrappedComponentRef={this.saveFormRef}
          visible={this.state.modalVisible}
          onCancel={() =>
            this.setState({
              modalVisible: false,
            })
          }
          modalType={this.state.grupoId == '0' ? 'edit' : 'create'}
          onCreate={this.handleCreate}
          materias={this.state.materias}
        />
      </Card>
    );
  }
}

export default Grupos;
