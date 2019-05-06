import * as React from 'react';
import Form, { FormComponentProps } from 'antd/lib/form';
import { Modal, InputNumber } from 'antd';
//import FormItem from 'antd/lib/form/FormItem';
import FormItem from 'antd/lib/form/FormItem';
import { AlumnoInscrito } from 'src/models/Grupo/GrupoModel';
//import rules from './createOrUpdateGrupo.validation';

//const { Option, OptGroup } = Select;

export interface ICalificarGrupo extends FormComponentProps {
  alumnosInscritos: AlumnoInscrito[];
  visible: boolean;
  onCancel: () => void;
  modalType: string;
  onCalificar: () => void;
}

class CalificarGrupo extends React.Component<ICalificarGrupo> {
  render() {
    const formItemLayout = {
      labelCol: {
        xs: { span: 18 },
        sm: { span: 18 },
        md: { span: 18 },
        lg: { span: 18 },
        xl: { span: 18 },
        xxl: { span: 18 },
      },
      wrapperCol: {
        xs: { span: 4 },
        sm: { span: 4 },
        md: { span: 4 },
        lg: { span: 4 },
        xl: { span: 4 },
        xxl: { span: 4 },
      },
    };

    const { getFieldDecorator } = this.props.form;
    const { visible, onCancel, onCalificar } = this.props;

    return (
      <Modal visible={visible} cancelText={'Cerrar'} okText={'Inscribir'} onOk={onCalificar} onCancel={onCancel} title={'Calificar Grupo'}>
        {this.props.alumnosInscritos.length > 0 ? (
          this.props.alumnosInscritos.map(x => (
            <FormItem style={{ margin: 20 }} key={x.matricula} {...formItemLayout} label={x.nombre}>
              {getFieldDecorator(x.matricula.toString())(<InputNumber />)}
            </FormItem>
          ))
        ) : (
          <div>No hay alumnos para calificar</div>
        )}
      </Modal>
    );
  }
}

export default Form.create()(CalificarGrupo);
