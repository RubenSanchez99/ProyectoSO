import * as React from 'react';
import Form, { FormComponentProps } from 'antd/lib/form';
import { Modal, Select, InputNumber, Checkbox, Row, Col } from 'antd';
import FormItem from 'antd/lib/form/FormItem';
//import rules from './createOrUpdateGrupo.validation';

const { Option, OptGroup } = Select;

export interface ICreateOrUpdateGrupoProps extends FormComponentProps {
  materias: { [key: string]: GetAllMateriasOutput[] };
  visible: boolean;
  onCancel: () => void;
  modalType: string;
  onCreate: () => void;
}

class CreateGrupo extends React.Component<ICreateOrUpdateGrupoProps> {
  render() {
    const formItemLayout = {
      labelCol: {
        xs: { span: 6 },
        sm: { span: 6 },
        md: { span: 6 },
        lg: { span: 6 },
        xl: { span: 6 },
        xxl: { span: 6 },
      },
      wrapperCol: {
        xs: { span: 18 },
        sm: { span: 18 },
        md: { span: 18 },
        lg: { span: 18 },
        xl: { span: 18 },
        xxl: { span: 18 },
      },
    };

    const materiasItems = Object.keys(this.props.materias).map(x => (
      <OptGroup key={x} label={'Semestre ' + x}>
        {this.props.materias[x].map(x => (
          <Option key={x.id} value={x.id}>
            {x.nombre}
          </Option>
        ))}
      </OptGroup>
    ));

    const { getFieldDecorator } = this.props.form;
    const { visible, onCancel, onCreate } = this.props;

    return (
      <Modal visible={visible} cancelText={'Cancelar'} okText={'Aceptar'} onCancel={onCancel} onOk={onCreate} title={'Grupo'}>
        <FormItem style={{ margin: 20 }} label={'Materia'} {...formItemLayout}>
          {getFieldDecorator('mat')(
            <Select style={{ width: '100%' }} placeholder="Seleccione una materia">
              {materiasItems}
            </Select>
          )}
        </FormItem>

        <FormItem style={{ margin: 20 }} label={'Capacidad'} {...formItemLayout}>
          {getFieldDecorator('cap')(<InputNumber style={{ width: '100%' }} />)}
        </FormItem>

        <Form.Item style={{ margin: 20 }} {...formItemLayout} label="Días">
          {getFieldDecorator('dias', {
            initialValue: [],
          })(
            <Checkbox.Group style={{ width: '100%' }}>
              <Row>
                <Col span={8}>
                  <Checkbox value="Lunes">Lunes</Checkbox>
                </Col>
                <Col span={8}>
                  <Checkbox value="Martes">Martes</Checkbox>
                </Col>
                <Col span={8}>
                  <Checkbox value="Miercoles">Miércoles</Checkbox>
                </Col>
                <Col span={8}>
                  <Checkbox value="Jueves">Jueves</Checkbox>
                </Col>
                <Col span={8}>
                  <Checkbox value="Viernes">Viernes</Checkbox>
                </Col>
              </Row>
            </Checkbox.Group>
          )}
        </Form.Item>

        <FormItem style={{ margin: 20 }} label={'Hora'} {...formItemLayout}>
          {getFieldDecorator('hor')(
            <Select style={{ width: '100%' }} placeholder="Seleccione una hora">
              <Option value={1}>7:00-8:00</Option>
              <Option value={2}>8:00-9:00</Option>
              <Option value={3}>9:00-10:00</Option>
              <Option value={4}>10:00-11:00</Option>
              <Option value={5}>11:00-12:00</Option>
              <Option value={6}>12:00-13:00</Option>
              <Option value={7}>13:00-14:00</Option>
              <Option value={8}>14:00-15:00</Option>
              <Option value={9}>15:00-16:00</Option>
              <Option value={10}>16:00-17:00</Option>
              <Option value={11}>17:00-18:00</Option>
              <Option value={12}>18:00-19:00</Option>
              <Option value={13}>19:00-20:00</Option>
              <Option value={14}>20:00-21:00</Option>
              <Option value={15}>21:00-22:00</Option>
            </Select>
          )}
        </FormItem>
      </Modal>
    );
  }
}

export default Form.create()(CreateGrupo);
