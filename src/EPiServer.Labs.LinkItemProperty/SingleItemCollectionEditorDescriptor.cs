using System;
using System.Collections.Generic;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Shell;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using EPiServer.SpecializedProperties;

namespace EPiServer.Labs.LinkItemProperty
{
    /// <summary>
    /// Editor descriptor that a base class for all collection editor descriptors
    /// <see cref="EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors.LinkCollectionEditorDescriptor"/>
    /// </summary>
    [EditorDescriptorRegistration(TargetType = typeof(LinkItemCollection), UIHint = "SingleItem")]
    public class SingleItemCollectionEditorDescriptor : LinkCollectionEditorDescriptor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors.ItemCollectionEditorDescriptor" /> class.
        /// </summary>
        public SingleItemCollectionEditorDescriptor(IEnumerable<IContentRepositoryDescriptor> contentRepositoryDescriptors): base(contentRepositoryDescriptors)
        {
            ClientEditingClass = "episerver-labs-linkitem-property/editors/link-item-editor";
        }


        /// <summary>
        /// Modifies the metadata.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="attributes">The attributes.</param>
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            base.ModifyMetadata(metadata, attributes);

            metadata.OverlayConfiguration["customType"] = "episerver-labs-linkitem-property/widget/overlay/list-item-editor";
        }
    }
}
