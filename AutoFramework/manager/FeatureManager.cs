namespace AutoFramework.Manager
{
    public static class FeatureManager
    {
        public static T GetFeature<T>() where T : new()
        {
            var feature = new T();
            return feature;
        }
    }
}
