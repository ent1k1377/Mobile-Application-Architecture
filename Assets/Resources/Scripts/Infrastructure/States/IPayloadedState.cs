﻿namespace Resources.Scripts.Infrastructure.States
{
    public interface IPayloadedState<TPayload> : IExitableState
    {
        public void Enter(TPayload payload);
    }
}