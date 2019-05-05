import * as React from 'react';
import Form, { FormComponentProps } from 'antd/lib/form';
import { Tabs, Modal, Input } from 'antd';
import FormItem from 'antd/lib/form/FormItem';
import rules from './createOrUpdateAlumno.validation';

const TabPane = Tabs.TabPane;

export interface ICreateOrUpdateAlumnoProps extends FormComponentProps {
  visible: boolean;
  onCancel: () => void;
  modalType: string;
  onCreate: () => void;
}

class CreateOrUpdateAlumno extends React.Component<ICreateOrUpdateAlumnoProps> {
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

    const { getFieldDecorator } = this.props.form;
    const { visible, onCancel, onCreate } = this.props;

    /*const columns = [
      { title: 'ID', dataIndex: 'id', key: 'id', width: 150, render: (text: string) => <div>{text}</div> },
      { title: 'Nombre', dataIndex: 'nombre', key: 'nombre', width: 150, render: (text: string) => <div>{text}</div> },
    ];*/

    return (
      <Modal visible={visible} cancelText={'Cancelar'} okText={'Aceptar'} onCancel={onCancel} onOk={onCreate} title={'Alumno'}>
        <Tabs defaultActiveKey={'alumnoInfo'} size={'small'} tabBarGutter={64}>
          <TabPane tab={'Alumno'} key={'alumno'}>
            <FormItem label={'Nombre'} {...formItemLayout}>
              {getFieldDecorator('nombre', { rules: rules.nombre })(<Input />)}
            </FormItem>
            <FormItem label={'Apellido Paterno'} {...formItemLayout}>
              {getFieldDecorator('apellidoPaterno', { rules: rules.apellidoPaterno })(<Input />)}
            </FormItem>
            <FormItem label={'Apellido Materno'} {...formItemLayout}>
              {getFieldDecorator('apellidoMaterno', { rules: rules.apellidoMaterno })(<Input />)}
            </FormItem>
          </TabPane>
          <TabPane tab={'Horario'} key={'horario'} />
        </Tabs>
      </Modal>
    );
  }
}

export default Form.create()(CreateOrUpdateAlumno);
