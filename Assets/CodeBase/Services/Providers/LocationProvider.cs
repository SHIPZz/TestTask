﻿using System.Collections.Generic;
using CodeBase.Enums;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace CodeBase.Services.Providers
{
    public class LocationProvider : SerializedMonoBehaviour
    {
        [OdinSerialize] private Dictionary<LocationTypeId, Transform> _transforms;

        public Transform Get(LocationTypeId locationTypeId) =>
            _transforms[locationTypeId];
    }
}