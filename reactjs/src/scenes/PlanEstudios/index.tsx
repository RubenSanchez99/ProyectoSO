import AppComponentBase from 'src/components/AppComponentBase';
import PlanEstudiosStore from 'src/stores/planEstudiosStore';
import * as React from 'react';
import { Card, Row, Col, Table } from 'antd';
import { observer, inject } from 'mobx-react';
import Stores from 'src/stores/storeIdentifier';

export interface IPlanEstudiosProps {
  planEstudiosStore: PlanEstudiosStore;
}

export interface IPlanEstudiosState {}

@inject(Stores.PlanEstudiosStore)
@observer
class PlanEstudios extends AppComponentBase<IPlanEstudiosProps, IPlanEstudiosState> {
  async componentDidMount() {
    await this.getAll();
  }

  async getAll() {
    await this.props.planEstudiosStore.getAll();
  }

  public render() {
    const { materias } = this.props.planEstudiosStore;
    const columns = [
      { title: 'Matricula', dataIndex: 'id', key: 'id', width: 150, render: (text: string) => <div>{text}</div> },
      { title: 'Nombre', dataIndex: 'nombre', key: 'nombre', width: 150, render: (text: string) => <div>{text}</div> },
      { title: 'Semestre', dataIndex: 'semestre', key: 'semestre', width: 150, render: (text: string) => <div>{text}</div> },
      { title: 'Requisito', dataIndex: 'materiaRequisito.nombre', key: 'materiaRequisito', width: 150, render: (text: string) => <div>{text}</div> },
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
            <h2>{'Materias'}</h2>
          </Col>
          <Col
            xs={{ span: 14, offset: 0 }}
            sm={{ span: 15, offset: 0 }}
            md={{ span: 15, offset: 0 }}
            lg={{ span: 1, offset: 21 }}
            xl={{ span: 1, offset: 21 }}
            xxl={{ span: 1, offset: 21 }}
          >
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
              rowKey={record => record.id}
              size={'default'}
              bordered={true}
              columns={columns}
              loading={materias == undefined ? true : false}
              dataSource={materias == undefined ? [] : materias.items}
            />
          </Col>
        </Row>
      </Card>
    );
  }
}

export default PlanEstudios;
