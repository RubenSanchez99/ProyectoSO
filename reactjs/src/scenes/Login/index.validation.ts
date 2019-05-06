const rules = {
  userNameOrEmailAddress: [
    {
      required: true,
      message: 'Requerido',
    },
  ],
  password: [{ required: true, message: 'Requerido' }],
};

export default rules;
