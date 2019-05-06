import * as React from 'react';
import Form, { FormComponentProps } from 'antd/lib/form';
import { Modal, Select } from 'antd';
//import FormItem from 'antd/lib/form/FormItem';
import { observer } from 'mobx-react';
import FormItem from 'antd/lib/form/FormItem';
//import rules from './createOrUpdateGrupo.validation';

//const { Option, OptGroup } = Select;
const { Option } = Select;

export interface IInscribirAlumno extends FormComponentProps {
  alumnos: GetAlumnosOutput[];
  visible: boolean;
  onCancel: () => void;
  modalType: string;
  onAlumnoAdd: () => void;
}

@observer
class InscribirAlumno extends React.Component<IInscribirAlumno> {
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
    const { visible, onCancel, onAlumnoAdd } = this.props;

    return (
      <Modal visible={visible} cancelText={'Cerrar'} okText={'Inscribir'} onOk={onAlumnoAdd} onCancel={onCancel} title={'Inscribir alumno a grupo'}>
        <FormItem style={{ margin: 20 }} label={'Alumno'} {...formItemLayout}>
          {getFieldDecorator('mat')(
            <Select style={{ width: '100%' }} placeholder="Seleccione un alumno">
              {this.props.alumnos.map(x => (
                <Option key={x.matricula} value={x.matricula}>
                  {x.nombre}
                </Option>
              ))}
            </Select>
          )}
        </FormItem>
      </Modal>
    );
  }
}

export default Form.create()(InscribirAlumno);
