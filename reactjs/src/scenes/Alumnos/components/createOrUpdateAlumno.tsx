import * as React from 'react';
import Form, { FormComponentProps } from 'antd/lib/form';
import { Modal, Input } from 'antd';
import FormItem from 'antd/lib/form/FormItem';
import rules from './createOrUpdateAlumno.validation';

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
        xs: { span: 8 },
        sm: { span: 8 },
        md: { span: 8 },
        lg: { span: 8 },
        xl: { span: 8 },
        xxl: { span: 8 },
      },
      wrapperCol: {
        xs: { span: 16 },
        sm: { span: 16 },
        md: { span: 16 },
        lg: { span: 16 },
        xl: { span: 16 },
        xxl: { span: 16 },
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
        <FormItem style={{ margin: 20 }} label={'Nombre'} {...formItemLayout}>
          {getFieldDecorator('nombre', { rules: rules.nombre })(<Input />)}
        </FormItem>
        <FormItem style={{ margin: 20 }} label={'Apellido Paterno'} {...formItemLayout}>
          {getFieldDecorator('apellidoPaterno', { rules: rules.apellidoPaterno })(<Input />)}
        </FormItem>
        <FormItem style={{ margin: 20 }} label={'Apellido Materno'} {...formItemLayout}>
          {getFieldDecorator('apellidoMaterno', { rules: rules.apellidoMaterno })(<Input />)}
        </FormItem>
      </Modal>
    );
  }
}

export default Form.create()(CreateOrUpdateAlumno);
